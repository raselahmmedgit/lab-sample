import { Component, OnInit } from '@angular/core';
import { EmailSenderService } from 'src/app/services/email-sender.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

  constructor(private emailSenderService: EmailSenderService) { }

  ngOnInit() {
  }
  onEmailSendClick() {
    console.log('Email Send Click!');
    this.emailSenderService.sendEmail();
  }

}
