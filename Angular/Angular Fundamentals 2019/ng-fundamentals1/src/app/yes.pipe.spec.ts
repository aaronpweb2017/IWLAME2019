import { YesPipe } from './yes.pipe';

describe('YesPipe', () => {
  it('create an instance', () => {
    const pipe = new YesPipe();
    expect(pipe).toBeTruthy();
  });
});
