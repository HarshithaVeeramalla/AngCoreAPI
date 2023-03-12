import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.css'],
})
export class CallbackComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private authService: AuthenticationService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      console.log('params', params);
      if (!params || !params['code']) {
        this.redirectHome();
      }
      const domainUrl = window.location.host;
      this.http
        .get(
          `https://${domainUrl}/api/discord/access-token?code=${params['code']}&redirectUrl=https://${domainUrl}/callback`
        )
        .subscribe((response: any) => {
          console.log('response from post', response);
          if (response.access_token) {
            this.authService.login(response.access_token);
          }
          this.redirectHome();
        });
    });
  }
  redirectHome() {
    this.router.navigate(['home']);
  }
}
