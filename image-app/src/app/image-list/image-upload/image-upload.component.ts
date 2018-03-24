import { Component, OnInit, ChangeDetectionStrategy, ViewChild, ElementRef } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import * as imageReducer from '../../../redux/reducers/images.reducer';
import * as imageActions from '../../../redux/actions/image.actions';

@Component({
  selector: 'image-upload',
  templateUrl: './image-upload.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent {
  @ViewChild("fileUpload") fileUpload: any;

  constructor(private activeModalService: NgbActiveModal,
    private store: Store<imageReducer.State>) { }

  uploadClick() {
    const fileList: FileList = this.fileUpload.nativeElement.files;
    if (fileList.length > 0) {
      this.store.dispatch(new imageActions.UploadImageAction(fileList[0]));
    }
    this.activeModalService.close();
  }

  closeModal() {
    this.activeModalService.close();
  }
}
