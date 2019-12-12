import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfigService } from './appconfig.service';
import { Observable } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Payment } from '../pages/payment/payment.model';

@Injectable({
    providedIn: "root"
})
export class PaymentSqlService {
    handleError: any;
    constructor(private http: HttpClient, private appConfig: AppConfigService) {
    }

    getAllPaymentHistories(): Observable<Payment[]> {
        let url = this.appConfig.baseUrl + "/paymenthistories";
        return this.http.get<Payment[]>(url)
            .pipe(
                retry(3), // retry a failed request up to 3 times
                catchError(this.handleError) // then handle the error
            );
    }
    addPayment(payment: Payment) {
        let url = this.appConfig.baseUrl + "/paymenthistories";
        return this.http.post(url, payment);
    }
    deletePayment(id: any) {
        let url = this.appConfig.baseUrl + "/paymenthistories/" + id;
        return this.http.delete(url);
    }
}