import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    model:any={}
    loggedIn: boolean = false;
  constructor(private accountService:AccountService, private router:Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login(){

    this.accountService.login(this.model).subscribe(response =>{
 //     console.log(response);
      this.loggedIn =true;
      this.router.navigateByUrl('/puppy-list');
    }, error => {
      console.log(this.model);
      this.toastr.error(error.error)
    })
  }
}

