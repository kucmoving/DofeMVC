import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { Puppy } from 'src/app/_models/puppy';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_service/account.service';
import { PuppiesService } from 'src/app/_service/puppies.service';
import {take} from 'rxjs/operators'
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Photo } from 'src/app/_models/photo';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-puppy-edit',
  templateUrl: './puppy-edit.component.html',
  styleUrls: ['./puppy-edit.component.scss']
})
export class PuppyEditComponent implements OnInit {
    baseUrl = environment.apiUrl;
    puppy: Puppy;
    photo: Photo;
    user: User;
    file : any;
    @ViewChild('editForm') editForm:NgForm;
    @HostListener('window:beforeunload', ['$event']) unloadNotifaction($event: any){
        if (this.editForm.dirty) {
          $event.returnValue = true;
        }
      }


  constructor(private accountService: AccountService, private puppiesService: PuppiesService
    ,private toastr: ToastrService, private http : HttpClient, private router: Router) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user =user);
  }


  ngOnInit(): void {
    this.loadPuppy();
   // console.log(this.puppy);
  }

  loadPuppy(){
    this.puppiesService.getPuppy(this.user.username).subscribe((puppy => {
      this.puppy = puppy;
    }))
  }

  updatePuppy(){
    this.puppiesService.updatePuppy(this.puppy).subscribe(() => {
    //    console.log(this.puppy);
        this.editForm.reset(this.puppy);
        this.toastr.success("profile update! will be redirected to homepage after 3 seconds");
        setTimeout(()=>{ this.router.navigateByUrl("puppy-list/" + this.puppy.userName);}, 3000)})
}

  getFile(event: any){
    this.file = event.target.files[0];
   // console.log("file", this.file)
  };

  uploadPhoto(){
    let formData = new FormData();
    formData.set("file", this.file);
    return this.http.post(this.baseUrl + "User/add-photo", formData).subscribe((response) => {
      this.toastr.success("photo upload. will be redirected to homepage after 3 seconds");
      setTimeout(()=>{ this.router.navigateByUrl("puppy-list/" + this.puppy.userName);}, 3000)

      //要F5, 同埋loading效果
    })
  }
  setMainPhoto(photo: Photo){
    this.puppiesService.setMainPhoto(photo.id).subscribe(()=>{
      this.user.photoUrl = photo.url;
      this.accountService.setCurrentUser(this.user);
      this.puppy.photoUrl = photo.url;
      this.puppy.photos.forEach(p => {
        if (p.isMain) p.isMain =false;
        if (p.id === photo.id) p.isMain =true;
      })
    })
  }
  deletePhoto(photoId: number){
    this.puppiesService.deletePhoto(photoId).subscribe(() => {
      this.puppy.photos = this.puppy.photos.filter(x => x.id !== photoId);
    })
  }

}

