import { Injectable } from '@angular/core';
import { Login } from '../pages/login/login.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  loginUser: Login = {
    username: '',
    password: ''
  }
  constructor() { }

  getLoggedIn() {
    return this.loginUser;
  }

}
