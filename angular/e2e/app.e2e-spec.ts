import { AIVoiceInteractorTemplatePage } from './app.po';

describe('AIVoiceInteractor App', function() {
  let page: AIVoiceInteractorTemplatePage;

  beforeEach(() => {
    page = new AIVoiceInteractorTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
