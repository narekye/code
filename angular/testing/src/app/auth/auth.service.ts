import * as firebase from 'firebase';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

    private token: string = null;
    constructor(private router: Router) { }

    public signUpUser(email: string, password: string) {
        firebase.auth().createUserWithEmailAndPassword(email, password).catch(
            error => console.log(error)
        )
    }

    public signInUser(email: string, password: string) {
        firebase.auth().signInWithEmailAndPassword(email, password).then(
            response => {
                this.router.navigate(['/']);
                firebase.auth().currentUser.getToken().then(
                    token => this.token = token
                )
            }
        ).catch(error => console.log(error));
    }

    public getToken() {
        if (firebase.auth().currentUser !== null) {
            firebase.auth().currentUser.getToken().then(
                token => this.token = token
            );
        }
        return this.token;
    }

    public logOut() {
        firebase.auth().signOut();
        this.token = null;
    }

    public isAuthenticated() {
        return this.token != null;
    }
}