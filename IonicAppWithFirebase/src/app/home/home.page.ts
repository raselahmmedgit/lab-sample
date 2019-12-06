import { Component } from '@angular/core';
import { NavController } from '@ionic/angular';
import { PixabayService } from '../services/pixabay.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  results: Observable<any>;
  searchTerm: string = 'nature';
  constructor(private navCtr: NavController, private pixabayService: PixabayService) { }

  onNextButtonClick() {
    this.navCtr.navigateForward('login');
  }
  searchChanged() {
    this.pixabayService.searchChanged(this.searchTerm).then(data => {
      this.results = data;
    })
  }

}
