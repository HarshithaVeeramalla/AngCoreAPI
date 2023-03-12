import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';
import { take } from 'rxjs';
import { authCodeFlowConfig } from './sso.config';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  constructor(http: HttpClient, private oauthService: OAuthService) {
    // this.configureSingleSignOn();
    http.get<WeatherForecast[]>('/api/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => console.error(error)
    );
    http
      .get('/api/now')
      //.pipe(take(1))
      .subscribe(
        (result) => {
          console.log('done', result);
        },
        (error) => console.error(error)
      );

    // http
    //   .post(
    //     'https://discord.com/api/oauth2/authorize?client_id=1083874894867091526&redirect_uri=https%3A%2F%2Flocalhost%3A4200%2Fhome&response_type=code&scope=identify',
    //     {}
    //   )
    //   .subscribe(
    //     (response) => {
    //       console.log('hello', response);
    //     },
    //     (error) => console.error(error)
    //   );
  }

  // login() {
  //   this.oauthService.initLoginFlow();
  // }

  // logout() {
  //   this.oauthService.logOut();
  //   //this.oauthService.revokeTokenAndLogout();
  // }

  get token() {
    // let claims: any = this.oauthService.getIdentityClaims();
    // console.log(claims);
    // return claims ? claims : null;
    return true;
  }

  // configureSingleSignOn() {
  //   console.log('configure');
  //   this.oauthService.configure(authCodeFlowConfig);
  //   this.oauthService.tokenValidationHandler = new JwksValidationHandler();
  //   console.log('loadDiscoveryDocumentAndTryLogin');
  //   this.oauthService.loadDiscoveryDocumentAndTryLogin();
  // }

  title = 'rardk.web.UI';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
