import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent implements OnInit {
  private isBusy: boolean = false;

  constructor(private activeModalService: NgbActiveModal) { }

  ngOnInit() {
  }

  uploadClick() {
    this.isBusy = true;
  }

  closeModal() {
    this.activeModalService.close();
  }
}
