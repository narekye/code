import { Component, OnInit } from '@angular/core';
import * as fire from 'firebase';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  loadedFeature = '';
  onNavigate(feature: string) {
    this.loadedFeature = feature;
  }

  ngOnInit() {
    fire.initializeApp({
      apiKey: "AIzaSyB0Spl6zAgIjfCQPUzdtr8PnzufBm8bLg0",
      authDomain: "recipe-book-66513.firebaseapp.com"
    });
  }
}
