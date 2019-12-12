import { Component, OnInit } from '@angular/core';
import { Payment } from './payment.model';
import { LoadingController, AlertController } from '@ionic/angular';
import { PaymentService } from 'src/app/services/payment.service';
import { Router } from '@angular/router';
import { CreditUnion } from './bank.model';
import { BankService } from 'src/app/services/bank.service';
import { BankSqlService } from 'src/app/services/bank-sql.service';
import { PaymentSqlService } from 'src/app/services/paymentsql.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.page.html',
  styleUrls: ['./payment.page.scss'],
})
export class PaymentPage implements OnInit {

  paymentModel: Payment = {
    payeeName: null,
    amount: null,
    creditUnionId: null
  };
  loader: any;
  creditUnions: CreditUnion[] = [];

  constructor(private router: Router,
    private paymentService: PaymentService,
    private loadingController: LoadingController,
    private alertController: AlertController,
    private bankService: BankService,
    private bankSqlService: BankSqlService,
    private paymentSqlService: PaymentSqlService) { }

  ngOnInit() {
    this.buildLoader();
    //this.loadCreditUnions();
    this.loadCredionUnionFromSql();
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
  loadCredionUnionFromSql() {
    this.bankSqlService.getAllBank().subscribe(response => {
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
    this.MakePaymentSql();
  }

  clearModel() {
    this.paymentModel.payeeName = null;
    this.paymentModel.amount = null;
  }
  validate() {
    return this.paymentModel.creditUnionId != null && this.paymentModel.amount != null;
  }
  MakePaymentFirebase() {
    if (!this.validate()) {
      //let msg = "<p>Your donation will be sent to American red cross</p><p>a NetGiver REGISTERED 501(c)(3) organization</p>"
      this.showAlert("Message", "All fields are required", null);
      return;
    }
    this.showLoader();

    this.paymentService.addPayment(this.paymentModel).then(() => {
      this.hideLoader();
      console.log('Payment Successfull!');
      this.clearModel();
      this.router.navigateByUrl('/payment-detail');
    },
      err => {
        console.log('Opps! There was a problem to make payment');
        this.hideLoader();
        this.showAlert('Message', 'Payment Failed!', null);
      });
  }
  MakePaymentSql() {
    if (!this.validate()) {
      let msg = "<p>Your donation will be sent to American red cross</p><p>a NetGiver REGISTERED 501(c)(3) organization</p>"
      this.showAlert("Message", null, msg);
      return;
    }
    this.showLoader();

    this.paymentSqlService.addPayment(this.paymentModel).subscribe(() => {
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




}
