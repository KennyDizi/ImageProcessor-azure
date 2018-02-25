import { Component, OnInit } from '@angular/core';
import { ImageService } from '../image.service';
import { Image } from '../image';
import { ImageItemComponent } from '../image-item/image-item.component';

@Component({
  selector: 'image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {
  private images: Image[];

  constructor(private imageService: ImageService) {
    this.images = [];
  }

  ngOnInit() {
    this.imageService.getImages()
      .subscribe(images => this.images = images);
  }

}
