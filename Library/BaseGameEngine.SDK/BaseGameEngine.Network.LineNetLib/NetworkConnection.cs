using BaseGameEngine.SDK.Network;

namespace BaseGameEngine.Network.LineNetLib
{
    public class NetworkConnection : INetworkConnection
    {
        public NetworkConnection(INetworkPeer peer) : base(peer)
        {
            
        }

        public NetworkConnection(INetworkPeer peer, INetworkObject gobject) : base(peer, gobject)
        {
            
        }
    }
}