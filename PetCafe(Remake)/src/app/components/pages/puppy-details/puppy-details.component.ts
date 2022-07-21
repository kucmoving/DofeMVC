import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { ToastrService } from 'ngx-toastr';
import { Puppy } from 'src/app/_models/puppy';
import { PuppiesService } from 'src/app/_service/puppies.service';

@Component({
  selector: 'app-puppy-details',
  templateUrl: './puppy-details.component.html',
  styleUrls: ['./puppy-details.component.scss']
})
export class PuppyDetailsComponent implements OnInit {
    puppy : Puppy;
    galleryOptions: NgxGalleryOptions[];
    galleryImages: NgxGalleryImage[];


  constructor(private puppiesService: PuppiesService, private route: ActivatedRoute,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.loadPuppy();


    this.galleryOptions = [
      {
        width:'500px',
        height:'500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
  }

  getImages(): NgxGalleryImage[] {
    const imageUrls = [];
    for (const photo of this.puppy.photos){
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url
      })
    }
    return imageUrls;
  }

  loadPuppy(){
    this.puppiesService.getPuppy(this.route.snapshot.paramMap.get("username")).subscribe(puppy => {
      this.puppy = puppy;
      this.galleryImages = this.getImages();
    })
  }

  addFollow(puppy:Puppy) {
    this.puppiesService.addFollow(puppy.userName).subscribe(()=>{
      this.toastr.success('You have followed ' + puppy.nickName);
    }, error => {
        this.toastr.error('Followed already');
      })
    }
}
