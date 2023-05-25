import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
   this.setCurrentUser(); //will set current user if there is any in the local storage
  }

  setCurrentUser(){
    //const user: User = JSON.parse(localStorage.getItem('user')!)  //!turn off typescript safety...override type
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);

  }
 
}
