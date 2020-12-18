
var DhtmlxScheduler = function () {

	var loadDhtmlxSchedulerTimeline = function () {
		$.ajax({
			url: "/Home/GetDhtmlxScheduler",
			type: 'GET',
			dataType: "json",
			beforeSend: function () {
				$.blockUI();
			},
			success: function (result) {
				if (result != null) {
					//downloadObjectAsJson(result, 'DhtmlxSchedulerJson');
					intDhtmlxSchedulerTimeline(result);
				}
				$.unblockUI();
			},
			error: function (error) {
				$.unblockUI();
				console.log(error);
			}

		});
	};

	var toJavaScriptDate = function (value) {
		var dt = new Date(value);
		var date = (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
		return date;
	}

	var toFormateDateTime = function (value) {
		var dt = new Date(value);
		var datetime = (`${(dt.getMonth() + 1).toString().padStart(2, '0')}/${dt.getDate().toString().padStart(2, '0')}/${dt.getFullYear().toString().padStart(4, '0')} ${dt.getHours().toString().padStart(2, '0')}:${dt.getMinutes().toString().padStart(2, '0')}:${dt.getSeconds().toString().padStart(2, '0')}`);
		return datetime;
	}

	function downloadObjectAsJson(exportObj, exportName) {
		var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(exportObj));
		var downloadAnchorNode = document.createElement('a');
		downloadAnchorNode.setAttribute("href", dataStr);
		downloadAnchorNode.setAttribute("download", exportName + ".txt");
		document.body.appendChild(downloadAnchorNode); // required for firefox
		downloadAnchorNode.click();
		downloadAnchorNode.remove();
	}

	var intDhtmlxSchedulerTimeline = function (data) {

		$.blockUI();

		console.log(data);

		//===============
		// Basic configuration
		//===============
		scheduler.locale.labels.timeline_tab = "Timeline";
		scheduler.locale.labels.section_custom = "Section";
		scheduler.config.details_on_create = true;
		scheduler.config.details_on_dblclick = true;

		//===============
		// Tooltip related code
		//===============

		// we want to save "dhx_cal_data" div in a variable to limit look ups
		var scheduler_container = document.getElementById("dhtmlxSchedulerContainer");
		var scheduler_container_divs = scheduler_container.getElementsByTagName("div");
		var dhx_cal_data = scheduler_container_divs[scheduler_container_divs.length - 1];

		// while target has parent node and we haven't reached dhx_cal_data
		// we can keep checking if it is timeline section
		scheduler.dhtmlXTooltip.isTooltipTarget = function (target) {
			while (target.parentNode && target != dhx_cal_data) {
				var css = target.className.split(" ")[0];
				// if we are over matrix cell or tooltip itself
				if (css == "dhx_matrix_scell" || css == "dhtmlXTooltip") {
					return { classname: css };
				}
				target = target.parentNode;
			}
			return false;
		};

		//scheduler.attachEvent("onMouseMove", function (id, e) {
		//	var timeline_view = scheduler.matrix[scheduler.getState().mode];

		//	// if we are over event then we can immediately return
		//	// or if we are not on timeline view
		//	if (id || !timeline_view) {
		//		return;
		//	}

		//	// native mouse event
		//	e = e || window.event;
		//	var target = e.target || e.srcElement;


		//	//make a copy of event, will be used in timed call, ie8 comp
		//	var ev = {
		//		'pageX': undefined,
		//		'pageY': undefined,
		//		'clientX': undefined,
		//		'clientY': undefined,
		//		'target': undefined,
		//		'srcElement': undefined
		//	};
		//	for (var i in ev) {
		//		ev[i] = e[i];
		//	}

		//	var tooltip = scheduler.dhtmlXTooltip;
		//	var tooltipTarget = tooltip.isTooltipTarget(target);
		//	if (tooltipTarget) {
		//		if (tooltipTarget.classname == "dhx_matrix_scell") {
		//			// we are over cell, need to get what cell it is and display tooltip
		//			var section_id = scheduler.getActionData(e).section;
		//			var section = timeline_view.y_unit[timeline_view.order[section_id]];

		//			// showing tooltip itself
		//			var text = "Tooltip for <b>" + section.label + "</b>";
		//			tooltip.delay(tooltip.show, tooltip, [ev, text]);
		//		}
		//		if (tooltipTarget.classname == "dhtmlXTooltip") {


		//			dhtmlxTooltip.delay(tooltip.show, tooltip, [ev, tooltip.tooltip.innerHTML]);
		//		}
		//	}
		//});

		//===============
		// DblClick Event
		//===============
		scheduler.attachEvent("onDblClick", function (id, e) {
			//any custom logic here
			console.log('onDblClick');
			return true;
		})
		//===============
		// DblClick Event
		//===============

		//===============
		// DblClick Event
		//===============
		scheduler.attachEvent("onCellDblClick", function (x_ind, y_ind, x_val, y_val, e) {
			//any custom logic here
			console.log('onCellDblClick');
		});
		//===============
		// DblClick Event
		//===============

		//===============
		// Drag Event
		//===============
		var dragged_event;
		scheduler.attachEvent("onBeforeDrag", function (id, mode, e) {
			console.log('onBeforeDrag');
			// use it to get the object of the dragged event
			dragged_event = scheduler.getEvent(id);
			return true;
		});

		scheduler.attachEvent("onDragEnd", function (id, mode, e) {
			var event_obj = dragged_event;
			console.log('onDragEnd');
			// your custom logic
		});
		//===============
		// Drag Event
		//===============

		//===============
		// Timeline configuration
		//===============
		var schedulerSections = data.sections;
		var sections = schedulerSections;
		//var sections = [
		//	{ key: 1, label: "James Smith" },
		//	{ key: 2, label: "John Williams" },
		//	{ key: 3, label: "David Miller" },
		//	{ key: 4, label: "Linda Brown" }
		//];

		scheduler.createTimelineView({
			name: "timeline",
			x_unit: "minute",
			x_date: "%H:%i",
			x_step: 30,
			x_size: 24,
			x_start: 16,
			x_length: 48,
			y_unit: sections,
			y_property: "section_id",
			render: "bar"
		});

		//===============
		// Data loading
		//===============
		scheduler.config.lightbox.sections = [
			{ name: "description", height: 130, map_to: "text", type: "textarea", focus: true },
			{ name: "custom", height: 23, type: "select", options: sections, map_to: "section_id" },
			{ name: "time", height: 72, type: "time", map_to: "auto" }
		];

		var currentDate = new Date(data.date);
		scheduler.init('dhtmlxSchedulerContainer', currentDate, "timeline");

		var schedulerItems = data.items;
		scheduler.parse(schedulerItems);
		//scheduler.parse([
		//	{ start_date: "2020-12-18 09:00", end_date: "2020-12-18 12:00", text: "Task A-12458", section_id: 1 },
		//	{ start_date: "2020-12-18 10:00", end_date: "2020-12-18 16:00", text: "Task A-89411", section_id: 1 },
		//	{ start_date: "2020-12-18 10:00", end_date: "2020-12-18 14:00", text: "Task A-64168", section_id: 1 },
		//	{ start_date: "2020-12-18 16:00", end_date: "2020-12-18 17:00", text: "Task A-46598", section_id: 1 },

		//	{ start_date: "2020-12-18 12:00", end_date: "2020-12-18 20:00", text: "Task B-48865", section_id: 2 },
		//	{ start_date: "2020-12-18 14:00", end_date: "2020-12-18 16:00", text: "Task B-44864", section_id: 2 },
		//	{ start_date: "2020-12-18 16:30", end_date: "2020-12-18 18:00", text: "Task B-46558", section_id: 2 },
		//	{ start_date: "2020-12-18 18:30", end_date: "2020-12-18 20:00", text: "Task B-45564", section_id: 2 },

		//	{ start_date: "2020-12-18 08:00", end_date: "2020-12-18 12:00", text: "Task C-32421", section_id: 3 },
		//	{ start_date: "2020-12-18 14:30", end_date: "2020-12-18 16:45", text: "Task C-14244", section_id: 3 },

		//	{ start_date: "2020-12-18 09:20", end_date: "2020-12-18 12:20", text: "Task D-52688", section_id: 4 },
		//	{ start_date: "2020-12-18 11:40", end_date: "2020-12-18 16:30", text: "Task D-46588", section_id: 4 },
		//	{ start_date: "2020-12-18 12:00", end_date: "2020-12-18 18:00", text: "Task D-12458", section_id: 4 }
		//]);

		//===============
		// Customize tooltip
		//===============
		scheduler.templates.tooltip_text = function (start, end, event) {
			return "<b>" + event.text + "</b><br/>" +
				"<b>Start Date Time:</b> " + toFormateDateTime(start) + "<br/>" +
				"<b>End Date Time:</b> " + toFormateDateTime(end);
		};

		$.unblockUI();

    };

    return {
		LoadDhtmlxSchedulerTimeline: loadDhtmlxSchedulerTimeline,
    };
}();