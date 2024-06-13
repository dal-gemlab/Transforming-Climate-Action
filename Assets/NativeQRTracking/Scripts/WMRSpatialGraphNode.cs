using UnityEngine;

namespace QRTracking.WindowsMR
{
    internal enum FrameTime { OnUpdate, OnBeforeRender }

    internal class SpatialGraphNode
    {
        public System.Guid Id { get; private set; }
#if WINDOWS_UWP
            private Windows.Perception.Spatial.SpatialCoordinateSystem CoordinateSystem = null;
#endif

        public static SpatialGraphNode FromStaticNodeId(System.Guid id)
        {
#if WINDOWS_UWP
                var coordinateSystem = Windows.Perception.Spatial.Preview.SpatialGraphInteropPreview.CreateCoordinateSystemForNode(id);
                return coordinateSystem == null ? null :
                    new SpatialGraphNode()
                    {
                        Id = id,
                        CoordinateSystem = coordinateSystem
                    };
#endif
            return null;
        }


        public bool TryLocate(FrameTime frameTime, out Pose pose)
        {
            pose = Pose.identity;


            return false;
        }
    }
}