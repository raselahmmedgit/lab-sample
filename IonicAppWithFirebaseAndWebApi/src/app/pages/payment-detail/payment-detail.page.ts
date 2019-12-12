import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment/payment.model';
import { PaymentService } from 'src/app/services/payment.service';
import { AlertController } from '@ionic/angular';
import { AppLoaderService } from 'src/app/app-loader.service';
import { PaymentSqlService } from 'src/app/services/paymentsql.service';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.page.html',
  styleUrls: ['./payment-detail.page.scss'],
})
export class PaymentDetailPage implements OnInit {
  paymentDetails: Payment[] = [];
  loader: any;

  constructor(private paymentService: PaymentService, private appLoader: AppLoaderService, private alertController: AlertController, private paymentSqlService: PaymentSqlService) { }

  ngOnInit() {
    console.log(this.paymentDetails);
    //this.loadPayments();
    this.loadPaymentsFromSql();
  }

  ionViewDidEnter() {
    console.log('ionViewDidEnter');
    this.loadPaymentsFromSql();
  }

  loadPaymentsFromSql() {
    console.log('Load payments method called');
    this.appLoader.presentLoader('Pleaset wait...');
    this.paymentSqlService.getAllPaymentHistories().subscribe(response => {
      this.appLoader.dismissLoader();
      this.paymentDetails = response;
      console.log('Got the response');

    },
      () => {
        console.log('Error occured!');
        this.appLoader.dismissLoader();
      });
    console.log('Load payments method call ended');
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
            this.deleteFromSql(payment.id);
          }
        }
      ]
    });

    await alert.present();
  }

  deleteFromFirebase(id) {
    this.appLoader.presentLoader('Deleting record...');
    this.paymentService.deletePayment(id).then(() => {
      console.log('Delete Successfully');
      this.appLoader.dismissLoader();
    });
    console.log('Delete Selected');
  }

  deleteFromSql(id) {
    this.appLoader.presentLoader('Deleting record...');
    this.paymentSqlService.deletePayment(id).subscribe(() => {
      console.log('Delete Successfully');
      this.appLoader.dismissLoader();
      this.loadPaymentsFromSql();
    });
    console.log('Delete Selected');
  }

}

