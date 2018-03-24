
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

export function imagesReducer(state: State = initialState, action: Action) {
    switch (action.type) {
        case imageActions.LOAD_IMAGES_COMPLETE:
            state = Object.assign({}, state, {
                images: action.payload
            });
            break;

        case imageActions.UPLOAD_IMAGE_SUCCESS:
            state = Object.assign({}, state, {
                images: [
                    action.payload,
                    ...state.images
                ]
            });
            break;
    }

    return state;
}

export const getAllImages = (state: State) => state.images;