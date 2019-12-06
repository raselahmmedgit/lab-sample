import { Injectable } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { Payment } from '../pages/payment/payment.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})
export class PaymentService {
    private payments: Observable<Payment[]>;
    private paymentCollection: AngularFirestoreCollection<Payment>;

    constructor(private afs: AngularFirestore) {
        this.paymentCollection = this.afs.collection<Payment>('payments');
        this.payments = this.paymentCollection.snapshotChanges().pipe(
            map(actions => {
                return actions.map(a => {
                    const data = a.payload.doc.data();
                    const id = a.payload.doc.id;
                    return { id, ...data };
                });
            })
        );
    }

    getPayments(): Observable<Payment[]> {
        //return this.payments;
        this.payments.subscribe(d => {
            console.log(d);
        })
        //return this.paymentCollection.valueChanges();
        return this.paymentCollection.snapshotChanges().pipe(
            map(actions => {
                return actions.map(a => {
                    const data = a.payload.doc.data();
                    const id = a.payload.doc.id;
                    return { id, ...data };
                });
            })
        );

    }

    getPayment(id: string): Observable<Payment> {
        return this.paymentCollection.doc<Payment>(id).valueChanges().pipe(
            map(payment => {
                payment.id = id;
                return payment
            })
        );
    }

    addPayment(payment: Payment) {
        return this.paymentCollection.add(payment);
    }
    updatePayment(payment: Payment): Promise<void> {
        return this.paymentCollection.doc(payment.id).update({ name: payment.payeeName, amount: payment.amount });
    }
    deletePayment(id: string): Promise<void> {
        return this.paymentCollection.doc(id).delete();
    }


}