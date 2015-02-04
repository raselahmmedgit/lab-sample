var DummyProfile = [
    {
        "ProfileId": 1,
        "FirstName": "Anand",
        "LastName": "Pandey",
        "Email": "anand@anandpandey.com"
    },
    {
        "ProfileId": 2,
        "FirstName": "John",
        "LastName": "Cena",
        "Email": "john@cena.com"
    }
]

var ProfilesViewModel = function () {
    var self = this;
    var refresh = function () {
        self.Profiles(DummyProfile);
    };

    // Public data properties
    self.Profiles = ko.observableArray([]);

    self.createProfile = function () {
        console.log("Create a new profile");
        window.location.href = '/KnockOut/CreateOrEdit/0';
    };

    self.editProfile = function (profile) {
        console.log("Edit tis profile with profile id as :" + profile.ProfileId);
        window.location.href = '/KnockOut/CreateOrEdit/' + profile.ProfileId;
    };

    self.removeProfile = function (profile) {
        console.log("Remove tis profile with profile id as :" + profile.ProfileId);
        if (confirm("Are you sure you want to delete this profile?")) {
            self.Profiles.remove(profile);
        }
    };

    refresh();
};
ko.applyBindings(new ProfilesViewModel());

