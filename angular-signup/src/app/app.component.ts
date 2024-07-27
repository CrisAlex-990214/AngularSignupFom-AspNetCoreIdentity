import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { User } from './user';
import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FormsModule, HttpClientModule],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  user: User = { userName: '', email: '', password: '' };
  url = 'https://localhost:7266/';

  constructor(private http: HttpClient) { }

  registerUser() {
    this.http.post<number>(this.url, this.user).subscribe({
      next: id => alert('A new user was created with an id: ' + id),
      error: (err: HttpErrorResponse) => alert('Failed to create an user. Errors: ' + err.error)
    });
  }
}
