namespace Tutorial3.Interfaces;

public interface IHazardNotifier
{
    void SendHazardNotification(string message, string serialNumber);
}