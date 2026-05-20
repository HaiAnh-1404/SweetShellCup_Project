import svgPaths from "./svg-ge8enm74wk";
import imgFrame706 from "./df213688876a7cfb12afde1cc8555a134c98a7b0.png";

function Frame() {
  return (
    <div className="absolute h-[641px] left-[23px] top-[44px] w-[442px]">
      <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgFrame706} />
    </div>
  );
}

function StarIcon() {
  return (
    <div className="absolute h-[46px] left-[576px] top-[120px] w-[272px]" data-name="star-icon">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 272 46">
        <g id="star-icon">
          <path d={svgPaths.pf5a2880} fill="var(--fill-0, #FAF61E)" id="Star 1" />
          <path d={svgPaths.p3442f080} fill="var(--fill-0, #FAF61E)" id="Star 2" />
          <path d={svgPaths.p33515600} fill="var(--fill-0, #FAF61E)" id="Star 3" />
          <path d={svgPaths.p16ae2300} fill="var(--fill-0, #FAF61E)" id="Star 4" />
          <path d={svgPaths.p3a77a80} fill="var(--fill-0, #FAF61E)" id="Star 5" />
        </g>
      </svg>
    </div>
  );
}

export default function Detail() {
  return (
    <div className="bg-[#efeab8] relative size-full" data-name="Detail">
      <Frame />
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[76px] leading-none left-[560px] text-[#533931] text-[64px] top-[24px] w-[650px]">Cốc bột nguyên cám</p>
      <StarIcon />
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[48px] leading-none left-[896px] text-[40px] text-black top-[120px] w-[336px]">(120 đánh giá )</p>
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[48px] leading-none left-[579px] text-[#12161c] text-[40px] top-[300px] w-[336px]">Mô tả ngắn</p>
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[48px] leading-none left-[579px] text-[#17100e] text-[40px] top-[517px] w-[531px]">Thành phần</p>
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[115px] leading-none left-[576px] text-[#533931] text-[36px] top-[368px] w-[560px]">{`Vỏ ly giòn tan , thơm mùi bột nguyên cám tự nhiên , tốt cho sức khỏe `}</p>
      <div className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[115px] leading-[0] left-[579px] text-[#533931] text-[36px] top-[583px] w-[560px]">
        <p className="leading-none mb-[15px]">bột nguyên cám , trứng , đường</p>
        <p className="leading-none">bơ</p>
      </div>
      <p className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[48px] leading-none left-[579px] text-[40px] text-black top-[218px] w-[336px]">13.00$</p>
      <div className="absolute bg-[#533931] h-[66px] left-[571px] top-[852px] w-[304px]" />
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[33px] leading-none left-[729px] text-[36px] text-center text-white top-[871px] w-[232px]">Back</p>
    </div>
  );
}