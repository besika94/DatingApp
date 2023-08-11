import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title: string = 'client';
  users: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any>('https://localhost:5001/api/users').subscribe({
      next: (users) => (this.users = users),
      error: (err) => console.log(err),
      complete: () => console.log('completed'),
    });
  }
}
