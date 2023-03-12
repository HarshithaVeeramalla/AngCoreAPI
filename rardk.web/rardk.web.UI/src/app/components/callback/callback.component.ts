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
      this.http
        .get(
          `https://localhost:4200/api/discord/access-token?code=${params['code']}&redirectUrl=https://localhost:4200/callback`
        )
        .subscribe((response) => {
          console.log('response from post', response);
        });
    });
  }
}
