import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreditUnion } from '../pages/payment/bank.model';
import { catchError, retry } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { error } from 'selenium-webdriver';
import { AppConfigService } from './appconfig.service';

@Injectable({
    providedIn: "root"
})
export class BankSqlService {
    handleError: any;
    constructor(private http: HttpClient, private appConfig: AppConfigService) {
    }

    getAllBank(): Observable<CreditUnion[]> {
        let url = this.appConfig.baseUrl + "/creditunion";
        return this.http.get<CreditUnion[]>(url)
            .pipe(
                retry(3), // retry a failed request up to 3 times
                catchError(this.handleError) // then handle the error
            );
    }
}