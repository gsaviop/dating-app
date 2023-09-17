import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title: string = 'aoooooooo trein';
  users: any;

  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
      this.http.get("https://localhost:5103/api/users").subscribe({
        next: res => this.users = res,
        error: err => console.log(err),
        complete: () => console.log("deu certo pai")
      })
  }

}
