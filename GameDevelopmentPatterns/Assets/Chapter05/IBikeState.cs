using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
    public interface IBikeState
    {
        public void Handle(BikeController controller);
    }
}
