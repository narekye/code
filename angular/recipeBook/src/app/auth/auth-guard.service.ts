import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { AuthService } from './auth.service';
import { Observable } from "rxjs/Observable";

@Injectable()
export class AuthGuard implements CanActivate {
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
        return this.authService.isAuthenticated();
    }

    constructor(private authService: AuthService) { }
}