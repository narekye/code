import { Component } from '@angular/core';
import { DataStorageService } from '../shared/data-storage.service';
import { Response } from '@angular/http';
import { AuthService } from './../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent {

  constructor(private dataStorage: DataStorageService, private authService: AuthService) { }

  onSaveData() {
    this.dataStorage.storeRecipes().subscribe(
      (response: Response) => {
        console.log(response);
      });
  }

  onGetData() {
    this.dataStorage.getRecipes();
  }

  onLogOut() {
    this.authService.logOut();
  }
}

