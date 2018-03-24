import { Action } from "@ngrx/store";

import { Image } from '../../app/image';

export const LOAD_IMAGES = 'LOAD_IMAGES';
export const LOAD_IMAGES_COMPLETE = 'LOAD_IMAGES_COMPLETE';
export const LOAD_IMAGES_ERROR = 'LOAD_IMAGES_ERROR';

export class LoadImagesAction implements Action {
    readonly type = LOAD_IMAGES;
};

export class LoadImagesSuccessAction implements Action {
    readonly type = LOAD_IMAGES_COMPLETE;
    constructor(public payload: Image[]) {}
}

export class LoadImagesErrorAction implements Action {
    readonly type = LOAD_IMAGES_ERROR;
    constructor(public error: any) {}
}

export const UPLOAD_IMAGE = 'UPLOAD_IMAGE';
export const UPLOAD_IMAGE_SUCCESS = 'UPLOAD_IMAGE_SUCCESS';
export const UPLOAD_IMAGE_ERROR = 'UPLOAD_IMAGE_ERROR';

export class UploadImageAction implements Action {
    readonly type = UPLOAD_IMAGE;
    constructor(public payload: File) {}
}

export class UploadImageSucessAction implements Action {
    readonly type = UPLOAD_IMAGE_SUCCESS;
    constructor(public payload: Image) {}
}

export class UploadImageErrorAction implements Action {
    readonly type = UPLOAD_IMAGE_ERROR;
    constructor(public payload: Error) {}
}