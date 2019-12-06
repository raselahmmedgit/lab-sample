import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment/payment.model';
import { PaymentService } from 'src/app/services/payment.service';
import { AlertController } from '@ionic/angular';
import { AppLoaderService } from 'src/app/app-loader.service';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.page.html',
  styleUrls: ['./payment-detail.page.scss'],
})
export class PaymentDetailPage implements OnInit {
  paymentDetails: Payment[] = [];
  loader: any;

  constructor(private paymentService: PaymentService, private appLoader: AppLoaderService, private alertController: AlertController) { }

  ngOnInit() {
    console.log(this.paymentDetails);
    this.loadPayments();
  }
  loadPayments() {
    console.log('Load payments method called');
    this.appLoader.presentLoader('Pleaset wait...');
    this.paymentService.getPayments().subscribe(response => {
      this.paymentDetails = response;
      console.log('Got the response');
      this.appLoader.dismissLoader();
    },
      () => {
        console.log('Error occured!');
        this.appLoader.dismissLoader();
      });
    console.log('Load payments method call ended');
  }
  async viewPayment(payment: Payment) {
    console.log(payment);
    const alert = await this.alertController.create({
      header: 'Take Action!',
      animated: true,
      message: '',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            console.log('Confirm Cancel: blah');
          }
        },
        {
          text: 'Edit',
          cssClass: 'primary',
          handler: () => {
            console.log('Edit Selected');
          }
        },
        {
          text: 'Delete',
          cssClass: 'danger',
          handler: () => {
            this.appLoader.presentLoader('Deleting record...');
            this.paymentService.deletePayment(payment.id).then(() => {
              console.log('Delete Successfully');
              this.appLoader.dismissLoader();
            });
            console.log('Delete Selected');
          }
        }
      ]
    });

    await alert.present();
  }

}

