using Microsoft.ML.OnnxRuntime.Tensors;

namespace mummy.Models
{
    public class MummyData
    {
        public float squarenorthsouth { get; set; }
        public float squareeastwest { get; set; }
        public float northsouth_N { get; set; }
        public float eastwest_E { get; set; }
        public float eastwest_W { get; set; }
        public float adultsubadult_A { get; set; }
        public float adultsubadult_C { get; set; }
        public float adultsubadult_U { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_N { get; set; }
        public float ageatdeath_U { get; set; }
        public float thickness_C { get; set; }
        public float thickness_F { get; set; }
        public float thickness_F_M { get; set; }
        public float thickness_M { get; set; }
        public float thickness_U { get; set; }
        public float thickness_VF { get; set; }
        public float angle_H { get; set; }
        public float angle_M { get; set; }
        public float angle_M_H { get; set; }
        public float angle_S { get; set; }
        public float angle_S_M { get; set; }
        public float angle_U { get; set; }
        public float manipulation_Green_yarns { get; set; }
        public float manipulation_Thread_single_stitch { get; set; }
        public float manipulation_Warp { get; set; }
        public float manipulation_Weft { get; set; }
        public float manipulation_Weft_pile_band { get; set; }
        public float manipulation_Weft_red { get; set; }
        public float manipulation_Weft_Ribs { get; set; }
        public float manipulation_Weft_decoration { get; set; }
        public float material_Linen { get; set; }
        public float material_Other { get; set; }
        public float material_U { get; set; }
        public float material_Wool { get; set; }
        public float ply_D { get; set; }
        public float ply_S { get; set; }
        public float ply_U { get; set; }
        public float yarnmanipulation_direction_S { get; set; }
        public float yarnmanipulation_direction_U { get; set; }
        public float yarnmanipulation_direction_Z { get; set; }
        public float yarnmanipulation_direction_Z_S { get; set; }



        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                       squarenorthsouth, squareeastwest, northsouth_N, eastwest_E, eastwest_W, thickness_U, thickness_M, thickness_F_M, thickness_F, thickness_C, ageatdeath_U, ageatdeath_N, ageatdeath_I,
                       ageatdeath_C, ageatdeath_A, adultsubadult_U, adultsubadult_C, adultsubadult_A,
                       thickness_VF, angle_H, angle_M, angle_M_H, angle_S, angle_S_M, angle_U, manipulation_Green_yarns, manipulation_Thread_single_stitch,
                       manipulation_Warp, manipulation_Weft, manipulation_Weft_pile_band, manipulation_Weft_red, manipulation_Weft_Ribs,
                       manipulation_Weft_decoration, material_Linen, material_Other, material_U, material_Wool, ply_D,ply_S, ply_U,
                       yarnmanipulation_direction_S, yarnmanipulation_direction_U, yarnmanipulation_direction_Z, yarnmanipulation_direction_Z_S
            };
            int[] dimensions = new int[] { 1, 44 };
            return new DenseTensor<float>(data, dimensions);
        }
    }

}

