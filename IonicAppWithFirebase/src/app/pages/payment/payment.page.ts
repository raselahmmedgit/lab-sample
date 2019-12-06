import { Component, OnInit } from '@angular/core';
import { Payment } from './payment.model';
import { LoadingController, AlertController } from '@ionic/angular';
import { PaymentService } from 'src/app/services/payment.service';
import { Router } from '@angular/router';
import { CreditUnion } from './bank.model';
import { BankService } from 'src/app/services/bank.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.page.html',
  styleUrls: ['./payment.page.scss'],
})
export class PaymentPage implements OnInit {

  paymentModel: Payment = {
    payeeName: null,
    amount: null
  };
  loader: any;
  creditUnions: CreditUnion[] = [];

  constructor(private router: Router,
    private paymentService: PaymentService,
    private loadingController: LoadingController,
    private alertController: AlertController,
    private bankService: BankService) { }

  ngOnInit() {
    this.buildLoader();
    this.loadCreditUnions();
  }
  loadCreditUnions() {
    this.bankService.getCreditUnions().subscribe(response => {
      this.creditUnions = response;
      console.log('Response received...');
    },
      error => {
        console.log('Error Occured...');
      });

  }

  async showAlert(header, subHeader, message) {
    const alert = await this.alertController.create({
      header: header,
      subHeader: subHeader,
      message: message,
      buttons: ['OK']
    });
    await alert.present();
  }
  async buildLoader() {
    this.loader = await this.loadingController.create({
      message: "Processing...",
    });
  }
  async showLoader() {
    await this.loader.present();
  }
  async hideLoader() {
    await this.loader.dismiss();
  }
  onPayNowButtonClick() {
    if (!this.validate()) {
      this.showAlert("Message", "Please fill all the field", null);
      return;
    }
    this.showLoader();

    this.paymentService.addPayment(this.paymentModel).then(() => {
      //this.router.navigateByUrl('/');
      this.hideLoader();
      console.log('Payment Successfull!');
      this.clearModel();
      this.router.navigateByUrl('/payment-detail');
    },
      err => {
        console.log('Opps! There was a problem to make payment');
        //this.showToast('There was a problem adding your idea :(');
        this.hideLoader();
        this.showAlert('Message', 'Payment Failed!', null);
      });
  }

  clearModel() {
    this.paymentModel.payeeName = null;
    this.paymentModel.amount = null;
  }
  validate() {
    return this.paymentModel.payeeName != null && this.paymentModel.amount != null;
  }




}
