import { ImageAppPage } from './app.po';

describe('image-app App', () => {
  let page: ImageAppPage;

  beforeEach(() => {
    page = new ImageAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
