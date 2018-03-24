
import { ActionReducer, Action } from '@ngrx/store';
import { createSelector } from 'reselect';
import { Image } from '../../app/image';
import * as imageActions  from '../actions/image.actions';

export interface State {
    images: Image[],
};

const initialState: State = {
    images: []
}

export function imagesReducer(state: State = initialState, action: Action): any {
    switch (action.type) {
        case imageActions.LOAD_IMAGES_COMPLETE:
            const loadCompleteAction = action as imageActions.LoadImagesSuccessAction;
            state = Object.assign({}, state, {
                images: loadCompleteAction.payload
            });
            break;

        case imageActions.UPLOAD_IMAGE_SUCCESS:
            const uploadCompleteAction = action as imageActions.UploadImageSucessAction;
            state = Object.assign({}, state, {
                images: [
                    uploadCompleteAction.payload,
                    ...state.images
                ]
            });
            break;
    }

    return state;
}

export const getAllImages = (state: State) => state.images;