import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { CreditUnion } from '../pages/payment/bank.model';

@Injectable({
    providedIn: "root"
})
export class BankService {
    private banks: Observable<CreditUnion[]>;
    private bankCollection: AngularFirestoreCollection<CreditUnion>;

    constructor(private afs: AngularFirestore) {
        this.bankCollection = this.afs.collection<CreditUnion>('banks');
        this.banks = this.bankCollection.snapshotChanges().pipe(
            map(actions => {
                return actions.map(a => {
                    const data = a.payload.doc.data();
                    const id = a.payload.doc.id;
                    return { id, ...data };
                });
            })
        );
    }

    getCreditUnions(): Observable<CreditUnion[]> {
        //return this.payments;
        this.banks.subscribe(d => {
            console.log(d);
        })
        //return this.paymentCollection.valueChanges();
        return this.bankCollection.snapshotChanges().pipe(
            map(actions => {
                return actions.map(a => {
                    const data = a.payload.doc.data();
                    const id = a.payload.doc.id;
                    return { id, ...data };
                });
            })
        );

    }

}