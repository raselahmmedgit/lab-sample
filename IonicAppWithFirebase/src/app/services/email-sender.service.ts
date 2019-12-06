import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: "root"
})
export class EmailSenderService {
    url = "https://api.sendgrid.com/v3/mail/send";
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': 'Bearer  <API_KEY_HERE>'
        })
    };
    data = JSON.stringify({
        "personalizations": [
            {
                "to": [
                    {
                        "email": "nahidur@placovu.com",
                        "name": "Nahidur Rahman"
                    }
                ],
                "subject": "Message from ionic App!"
            }
        ],
        "from": {
            "email": "noreply@nahid.com",
            "name": "Nahid"
        },
        "reply_to": {
            "email": "noreply@nahid.com",
            "name": "Nahid"
        }
    });

    constructor(private http: HttpClient) {

    }

    sendEmail() {
        return this.http.post(this.url, this.data, this.httpOptions).subscribe(
            data => {
                console.log("POST Request is successful ", data);
            },
            error => {
                console.log("Error", error);
            });
    }

}