import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.css'],
})
export class CallbackComponent implements OnInit {
  constructor(private route: ActivatedRoute, private http: HttpClient) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      console.log('params', params);

      //old way to do it directly
      var clientId = 'placeholder';
      var clientSecret = 'placeholder';

      //has to be in this string format for some reason
      var bodyString = `client_id=${clientId}&client_secret=${clientSecret}&grant_type=authorization_code&code=${params['code']}&redirect_uri=https://localhost:4200/callback`;

      this.http
        // .post('https://discord.com/api/v10/oauth2/token', bodyString, {
        //   headers: {
        //     'Content-Type': 'application/x-www-form-urlencoded',
        //   },
        // })
        //new way
        .get(
          `https://localhost:4200/api/discord/access-token?code=${params['code']}&redirectUrl=https://localhost:4200/callback`
        )
        .subscribe((response) => {
          console.log('response from post', response);
        });
    });
  }
}
