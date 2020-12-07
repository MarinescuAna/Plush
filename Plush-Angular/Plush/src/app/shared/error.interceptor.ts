import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpEvent
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import{AuthService} from '../shared/auth.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AuthconfigInterceptor implements HttpInterceptor {

  constructor(private authenticationService:AuthService, private route: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
        if(this.authenticationService.isLogged()==false){
            this.route.navigateByUrl['\login'];
        }

        if ([401, 403].includes(err.status)) {
            // auto logout if 401 or 403 response returned from api
            this.authenticationService.doLogout();
        }

        const error = (err && err.error && err.error.message) || err.statusText;
        console.error(err);
        return throwError(error);
    }))
}
}
