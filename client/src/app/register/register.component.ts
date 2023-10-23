import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();

  model: any = {}

  constructor(private accountService: AccountService) {}
  
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  register() {
    this.accountService.register(this.model)
      .subscribe({
        next: res => {
          this.cancel();
        },
        error: error => console.log(error)
        
      })


    console.log(this.model);
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log("cancelled");
    
  }

}