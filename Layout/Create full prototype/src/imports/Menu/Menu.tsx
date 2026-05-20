import svgPaths from "./svg-r3psislfno";

function VuesaxLinearArrowDown() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/arrow-down">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 14 14">
        <g id="arrow-down">
          <path d={svgPaths.p1ab14f10} id="Vector" stroke="var(--stroke-0, black)" strokeLinecap="round" strokeLinejoin="round" strokeMiterlimit="10" strokeWidth="1.5" />
          <g id="Vector_2" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

export default function Menu() {
  return (
    <div className="relative size-full" data-name="menu">
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Work_Sans:Medium',sans-serif] font-medium leading-[0] left-[299.5px] text-[#533931] text-[0px] text-center top-0 whitespace-pre">
        <span className="leading-[1.1] text-[#f06b9a] text-[16px]">Home</span>
        <span className="leading-[1.1] text-[16px]">{`         `}</span>
        <span className="font-['Work_Sans:Regular',sans-serif] font-normal leading-[1.1] text-[16px]">{` `}</span>
        <span className="font-['Work_Sans:Regular',sans-serif] font-normal leading-[1.1] text-[16px]">Our Story</span>
        <span className="font-['Work_Sans:Regular',sans-serif] font-normal leading-[1.1] text-[16px]">{`         `}</span>
        <span className="font-['Work_Sans:Regular',sans-serif] font-normal leading-[1.1] text-[16px]">Shop</span>
        <span className="font-['Work_Sans:Regular',sans-serif] font-normal leading-[1.1] text-[16px]">{`         Cart          Feedback            Contact`}</span>
      </p>
      <div className="absolute left-[52px] size-[14px] top-[2px]" data-name="vuesax/linear/arrow-down">
        <VuesaxLinearArrowDown />
      </div>
    </div>
  );
}