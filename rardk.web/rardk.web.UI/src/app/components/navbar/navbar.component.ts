import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  constructor(private authService: AuthenticationService) {}

  logInWithDiscord() {
    const redirectUrlDomain = window.location.host;
    const discordAuthUrl = `https://discord.com/api/oauth2/authorize?client_id=1083874894867091526&redirect_uri=https%3A%2F%2F${redirectUrlDomain}%2Fcallback&response_type=code&scope=identify`;
    window.location.href = discordAuthUrl;
  }

  isLoggedIn() {
    return this.authService.isUserLoggedIn();
  }

  logOut() {
    this.authService.logout();
  }
}
