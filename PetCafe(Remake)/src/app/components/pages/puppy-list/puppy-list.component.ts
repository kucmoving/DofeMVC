
import { Pagination } from 'src/app/_models/pagination';
import { Puppy } from 'src/app/_models/puppy';
import { AccountService } from 'src/app/_service/account.service';
import { PuppiesService } from 'src/app/_service/puppies.service';
import {take} from 'rxjs/operators'
import { UserParams } from 'src/app/_models/userParams';
import { User } from 'src/app/_models/user';
import { Component, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-puppy-list',
  templateUrl: './puppy-list.component.html',
  styleUrls: ['./puppy-list.component.scss']
})
export class PuppyListComponent implements OnInit {
  puppies : Puppy[];
  @Output() Puppies;
  pagination: Pagination;
  userParams : UserParams;
  user: User;
  roleList = [{value:'Traveller', display:'Traveller'}, {value: 'Guide', display:'Guide'}];

  constructor(private puppiesService: PuppiesService, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
    this.user = user;
    this.userParams = new UserParams(user);});}

  ngOnInit(): void {
    this.loadPuppies();
  }

  loadPuppies(){
    this.puppiesService.getPuppies(this.userParams).subscribe(response=>{
      this.puppies = response.result;
   //   console.log(response.result)
   //   console.log(this.puppies)
   //   console.log(this.user)
      this.pagination = response.pagination;
    })
  }
  resetFilters(){
    this.userParams = new UserParams(this.user);
    this.loadPuppies();
  }

  pageChanged(event:any){
    this.userParams.pageNumber = event.page;
    this.loadPuppies();
  }
}
