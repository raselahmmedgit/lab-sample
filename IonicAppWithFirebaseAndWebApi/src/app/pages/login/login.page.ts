import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Login } from './login.model';
import { AlertController, LoadingController, NavController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  loginModel: Login = {
    username: null,
    password: null
  };
  loader: any;
  constructor(private productService: ProductService, private alertController: AlertController, private loadingController: LoadingController, private nav: NavController) { }

  ngOnInit() {
    this.buildLoader();
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
      duration: 2000
    });
  }
  async showLoader() {
    await this.loader.present();
  }
  async hideLoader() {
    await this.loader.dismiss();
  }

  async onLoginButtonClick() {
    await this.showLoader();
    if (!this.validate()) {
      await this.hideLoader();
      this.showAlert("Invalid Login", "Invalid username or password", null);
      return;
    }
    await this.hideLoader();
    this.nav.navigateForward('profile');


  }
  onCancelButtonClick() {
    this.loginModel.username = null;
    this.loginModel.password = null;
  }
  validate() {
    return this.loginModel.username != null && this.loginModel.password != null;
  }

}
