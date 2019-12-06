import { Injectable } from '@angular/core';
import { LoadingController } from '@ionic/angular';

@Injectable({
    providedIn: "root"
})
export class AppLoaderService {
    private loading: HTMLIonLoadingElement;
    private isShowing = false;

    constructor(private loadingController: LoadingController) { }

    public async presentLoader(message: string): Promise<void> {
        if (!this.isShowing) {
            this.isShowing = true;
            this.loading = await this.loadingController.create({
                message: message
            });
            return await this.loading.present();
        }
        else {
            // If loader is showing, only change text, won't create a new loader.
            this.isShowing = true;
            this.loading.message = message;
        }
    }

    public async dismissLoader(): Promise<void> {
        if (this.loading && this.isShowing) {
            this.isShowing = false;
            await this.loading.dismiss();
        }
    }

}