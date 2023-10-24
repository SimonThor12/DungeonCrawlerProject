using NAudio.Wave;

namespace DungeonCrawlerProject
{
  public class SoundManager
  {
    private WaveOutEvent waveOut;
    private WaveFileReader wavReader;

    public SoundManager(string wavFilePath)
    {
      waveOut = new WaveOutEvent();
      wavReader = new WaveFileReader(wavFilePath);
      waveOut.Init(wavReader);
    }

    public void PlaySound()
    {
      waveOut.Play();
    }
    public void StopSound()
    {
      waveOut.Stop();
    }
  }
}
