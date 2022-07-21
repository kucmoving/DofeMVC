import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_service/account.service';

@Component({
  selector: 'app-navbar-style-three',
  templateUrl: './navbar-style-three.component.html',
  styleUrls: ['./navbar-style-three.component.scss']
})
export class NavbarStyleThreeComponent implements OnInit {

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
