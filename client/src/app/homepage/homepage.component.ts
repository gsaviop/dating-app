import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.http.get("https://localhost:5103/api/users").subscribe({
      next: res => this.users = res,
      error: err => console.log(err),
      complete: () => console.log("deu certo pai")
    })
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
