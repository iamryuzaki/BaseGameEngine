namespace BaseGameEngine.SDK.Network
{
    public class INetworkConnection
    {
        public INetworkPeer ParentPeer { get; private set; }
        public INetworkObject GameObjectController { get; private set; }

        public INetworkConnection(INetworkPeer peer)
        {
            this.ParentPeer = peer;
            this.GameObjectController = null;
        }

        public INetworkConnection(INetworkPeer peer, INetworkObject gobject)
        {
            this.ParentPeer = peer;
            this.GameObjectController = gobject;
        }
    }
}