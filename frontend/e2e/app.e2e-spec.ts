import { SpacemathAppPage } from './app.po';

describe('spacemath-app App', () => {
  let page: SpacemathAppPage;

  beforeEach(() => {
    page = new SpacemathAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
