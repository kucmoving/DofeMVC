import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_service/account.service';

@Component({
  selector: 'app-navbar-style-one',
  templateUrl: './navbar-style-one.component.html',
  styleUrls: ['./navbar-style-one.component.scss']
})
export class NavbarStyleOneComponent implements OnInit {

    model: any={};
    loggedIn: boolean = false;

  constructor(public accountService:AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
  }
  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user;
    }, error => {
      console.log(error);
    })
  }
}



