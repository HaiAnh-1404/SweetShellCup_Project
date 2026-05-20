import svgPaths from "./svg-qfw3ge11ih";
import imgKisspngMuskStrawberryFruitFreshStrawberry5A80463Fcc12A41 from "./4a9f5df6931ddbf1d2f4cdf9ce61756e4d10f84f.png";
import imgRectangle24032 from "./a6d3982b69b8edb87cd58994f2143a29d7745ff9.png";
import imgImage378 from "./21d57254cea1097ecea8f83ce806e1d6717467d2.png";
import imgImage from "./fb385f754889b9e011d9c3e4f5aba98c74ea4773.png";
import imgDownload1 from "./2e85de38512f9c5df0a7c814707104057401c6f7.png";
import imgRectangle24040 from "./7efda8e16ee84538ecf3bc86cab7ed16eec89e11.png";
import imgImage377 from "./41c4e027ec33a88d308de32d3a3889de3bef29d9.png";

function VuesaxOutlineShoppingCart() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/outline/shopping-cart">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="shopping-cart">
          <path d={svgPaths.p3c066000} fill="var(--fill-0, #533931)" id="Vector" />
          <path d={svgPaths.pff6570} fill="var(--fill-0, #533931)" id="Vector_2" />
          <path d={svgPaths.p3e164800} fill="var(--fill-0, #533931)" id="Vector_3" />
          <path d={svgPaths.p1faa6100} fill="var(--fill-0, #533931)" id="Vector_4" />
          <g id="Vector_5" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Frame1() {
  return (
    <div className="absolute bg-[#ff4242] h-[18px] left-[1658px] rounded-[80px] top-[15px] w-[20px]">
      <div className="flex flex-col items-center justify-center size-full">
        <div className="content-stretch flex flex-col items-center justify-center p-[10px] relative size-full">
          <p className="[word-break:break-word] font-['Manrope:SemiBold',sans-serif] font-semibold leading-[25.2px] relative shrink-0 text-[12px] text-white uppercase whitespace-nowrap">1</p>
        </div>
      </div>
    </div>
  );
}

function Cart() {
  return (
    <div className="absolute contents left-[1640px] top-[15px]" data-name="cart">
      <div className="absolute left-[1640px] size-[24px] top-[20px]" data-name="vuesax/outline/shopping-cart">
        <VuesaxOutlineShoppingCart />
      </div>
      <Frame1 />
    </div>
  );
}

function VuesaxLinearProfile() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/profile">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="profile">
          <path d={svgPaths.p11b6c600} id="Vector" stroke="var(--stroke-0, #533931)" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" />
          <path d={svgPaths.p18d86500} id="Vector_2" stroke="var(--stroke-0, #533931)" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" />
          <g id="Vector_3" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function VuesaxLinearHeart() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/heart">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="heart">
          <path d={svgPaths.pd52c6b0} id="Vector" stroke="var(--stroke-0, #533931)" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" />
          <g id="Vector_2" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Icon() {
  return (
    <div className="absolute contents left-[1572px] top-[15px]" data-name="icon">
      <Cart />
      <div className="absolute left-[1572px] size-[24px] top-[20px]" data-name="vuesax/linear/profile">
        <VuesaxLinearProfile />
      </div>
      <div className="absolute left-[1606px] size-[24px] top-[20px]" data-name="vuesax/linear/heart">
        <VuesaxLinearHeart />
      </div>
    </div>
  );
}

function VuesaxLinearSearchNormal() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/search-normal">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 14 14">
        <g id="search-normal">
          <path d={svgPaths.p1851f600} id="Vector" stroke="var(--stroke-0, white)" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" />
          <path d={svgPaths.p1f740400} id="Vector_2" stroke="var(--stroke-0, white)" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" />
          <g id="Vector_3" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Icon1() {
  return (
    <div className="absolute contents left-[1644px] top-[96px]" data-name="icon">
      <div className="absolute left-[1644px] size-[14px] top-[96px]" data-name="vuesax/linear/search-normal">
        <VuesaxLinearSearchNormal />
      </div>
    </div>
  );
}

function Search() {
  return (
    <div className="absolute contents left-[1244px] top-[83px]" data-name="search">
      <div className="absolute bg-white border border-[#d8dbea] border-solid h-[40px] left-[1244px] rounded-[7px] top-[83px] w-[434px]" />
      <div className="absolute bg-[#f06b9a] h-[40px] left-[1623px] rounded-[7px] top-[83px] w-[55px]" />
      <p className="[word-break:break-word] absolute font-['Work_Sans:Regular',sans-serif] font-normal leading-[normal] left-[1264px] text-[#707d95] text-[14px] top-[95px] whitespace-nowrap">Search for...</p>
      <Icon1 />
    </div>
  );
}

function MaskGroup() {
  return (
    <div className="absolute contents left-[241px] top-[85px]" data-name="Mask group">
      <div className="absolute bg-[#533931] left-[227.29px] mask-alpha mask-intersect mask-no-clip mask-no-repeat mask-position-[13.714px_6.857px] mask-size-[40px_40px] size-[68.571px] top-[78.14px]" style={{ maskImage: `url('${imgRectangle24032}')` }} />
    </div>
  );
}

function Logo() {
  return (
    <div className="absolute contents left-[241px] top-[68px]" data-name="logo">
      <div className="-translate-y-1/2 [word-break:break-word] absolute flex flex-col font-['Work_Sans:ExtraBold',sans-serif] font-extrabold justify-center leading-[0] left-[292px] text-[#533931] text-[0px] top-[98px] whitespace-nowrap">
        <p className="leading-none mb-0 text-[20px]">​</p>
        <p className="leading-none mb-0 text-[#f06b9a] text-[20px]">Sweet</p>
        <p className="font-['Work_Sans:Regular',sans-serif] font-normal leading-none text-[20px]">{`Shell Cup `}</p>
      </div>
      <MaskGroup />
    </div>
  );
}

function Heading() {
  return (
    <div className="[word-break:break-word] absolute contents left-[177px] text-[#533931] top-[269px]" data-name="heading">
      <p className="-translate-x-1/2 absolute font-['Work_Sans:Regular',sans-serif] font-normal leading-[29px] left-[449.5px] text-[36px] text-center top-[617px] whitespace-nowrap">Hương vị của niềm vui trọn vẹn</p>
      <div className="-translate-y-1/2 absolute capitalize flex flex-col font-['Work_Sans:ExtraBold',sans-serif] font-extrabold justify-center leading-[0] left-[177px] text-[84px] top-[420.5px] w-[765px]">
        <p>
          <span className="leading-[1.2]">{`Ẩm thực toàn cầu gặp gỡ `}</span>
          <span className="leading-[1.2] text-[#fd84b2]">Sweet Shell Cup</span>
        </p>
      </div>
    </div>
  );
}

function TextImage() {
  return (
    <div className="absolute contents left-[177px] top-[221px]" data-name="text-image">
      <Heading />
      <div className="absolute h-[547px] left-[1042px] top-[221px] w-[820px]" data-name="image 378">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgImage378} />
      </div>
      <div className="absolute h-[72px] left-[1679px] top-[747px] w-[101px]" data-name="kisspng-musk-strawberry-fruit-fresh-strawberry-5a80463fcc12a4 2">
        <div className="absolute inset-0 overflow-hidden pointer-events-none">
          <img alt="" className="absolute h-[140.18%] left-0 max-w-none top-[-19.64%] w-full" src={imgKisspngMuskStrawberryFruitFreshStrawberry5A80463Fcc12A41} />
        </div>
      </div>
    </div>
  );
}

function Header() {
  return (
    <div className="absolute contents left-0 top-0" data-name="header">
      <div className="absolute h-[72px] left-[939px] top-[233px] w-[139px]" data-name="kisspng-musk-strawberry-fruit-fresh-strawberry-5a80463fcc12a4 1">
        <div className="absolute inset-0 overflow-hidden pointer-events-none">
          <img alt="" className="absolute h-[193.06%] left-0 max-w-none top-[-46.53%] w-full" src={imgKisspngMuskStrawberryFruitFreshStrawberry5A80463Fcc12A41} />
        </div>
      </div>
      <div className="absolute h-[5px] left-0 top-0 w-[1920px]">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 1920 5">
          <path d="M0 0H1920V5H0V0Z" fill="var(--fill-0, #F06B9A)" id="Rectangle 9180" />
        </svg>
      </div>
      <Icon />
      <p className="[word-break:break-word] absolute font-['Inter:Regular',sans-serif] font-normal leading-none left-[241px] not-italic text-[#533931] text-[16px] top-[21px] whitespace-nowrap">Free shipping on orders over $50</p>
      <div className="absolute h-0 left-[236px] top-[56px] w-[1443px]">
        <div className="absolute inset-[-1px_0_0_0]">
          <svg className="block size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 1443 1">
            <line id="Line 190" opacity="0.3" stroke="var(--stroke-0, #9D928F)" x2="1443" y1="0.5" y2="0.5" />
          </svg>
        </div>
      </div>
      <div className="absolute flex h-[18px] items-center justify-center left-[532px] top-[20px] w-0" style={{ "--transform-inner-width": "1185", "--transform-inner-height": "21" } as React.CSSProperties}>
        <div className="flex-none rotate-90">
          <div className="h-0 relative w-[18px]">
            <div className="absolute inset-[-1px_0_0_0]">
              <svg className="block size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 18 1">
                <line id="Line 187" opacity="0.3" stroke="var(--stroke-0, #9D928F)" x2="18" y1="0.5" y2="0.5" />
              </svg>
            </div>
          </div>
        </div>
      </div>
      <Search />
      <p className="[word-break:break-word] absolute font-['Inter:Regular',sans-serif] font-normal leading-none left-[572px] not-italic text-[#533931] text-[16px] top-[21px] whitespace-nowrap">{`Subscribe & get 15% off + FREE shipping`}</p>
      <Logo />
      <TextImage />
    </div>
  );
}

function PastriesInAdditionToIceCream() {
  return (
    <div className="absolute contents left-[14px] top-[901px]" data-name="Pastries In Addition To Ice Cream">
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:Bold',sans-serif] font-bold h-[74.474px] leading-[39px] left-[192px] text-[96px] text-black top-[901px] w-[1672.65px]">{`Câu Chuyện Sweet Shell Cup `}</p>
      <div className="absolute h-[1088px] left-[14px] top-[1036px] w-[1028px]" data-name="image">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgImage} />
      </div>
    </div>
  );
}

function Frame2() {
  return (
    <div className="absolute h-[1050px] left-[1042px] overflow-clip top-[1036px] w-[937px]">
      <div className="[word-break:break-word] absolute font-['Work_Sans:SemiBold',sans-serif] font-semibold h-[922px] leading-[0] left-[114px] text-[44px] text-black top-[90px] w-[654px] whitespace-pre-wrap">
        <p className="mb-[15px]">
          <span className="leading-[60px] text-[#f06b9a]">Sweet Shell Cup</span>
          <span className="leading-[60px]">{` bắt đầu từ `}</span>
        </p>
        <p className="leading-[60px] mb-[15px]">{`một câu hỏi rất đơn giản: tại `}</p>
        <p className="leading-[60px] mb-[15px]">{`sao một chiếc cốc chỉ được `}</p>
        <p className="leading-[60px] mb-[15px]">{`dùng trong vài phút rồi lại trở `}</p>
        <p className="leading-[60px] mb-[15px]">thành rác thải?</p>
        <p className="leading-[60px] mb-[15px]">{`Chúng tôi muốn biến chiếc `}</p>
        <p className="leading-[60px] mb-[15px]">{`cốc thành một phần của trải `}</p>
        <p className="leading-[60px] mb-[15px]">{`nghiệm, nơi khách hàng `}</p>
        <p className="leading-[60px] mb-[15px]">{`không chỉ thưởng thức đồ `}</p>
        <p className="leading-[60px] mb-[15px]">{`uống mà còn có thể tận `}</p>
        <p className="leading-[60px] mb-[15px]">hưởng luôn cả phần cuối cùng</p>
        <p className="leading-[60px]">sau khi uống xong.</p>
      </div>
      <div className="absolute h-[72px] left-[32px] top-0 w-[101px]" data-name="kisspng-musk-strawberry-fruit-fresh-strawberry-5a80463fcc12a4 3">
        <div className="absolute inset-0 overflow-hidden pointer-events-none">
          <img alt="" className="absolute h-[140.18%] left-0 max-w-none top-[-19.64%] w-full" src={imgKisspngMuskStrawberryFruitFreshStrawberry5A80463Fcc12A41} />
        </div>
      </div>
      <div className="absolute h-[72px] left-[768px] top-[950px] w-[101px]" data-name="kisspng-musk-strawberry-fruit-fresh-strawberry-5a80463fcc12a4 2">
        <div className="absolute inset-0 overflow-hidden pointer-events-none">
          <img alt="" className="absolute h-[140.18%] left-0 max-w-none top-[-19.64%] w-full" src={imgKisspngMuskStrawberryFruitFreshStrawberry5A80463Fcc12A41} />
        </div>
      </div>
    </div>
  );
}

function Frame() {
  return (
    <div className="absolute h-[320px] left-[14px] top-[2746px] w-[1920px]">
      <div className="-translate-x-1/2 absolute bg-[#e2d9c8] h-[320px] left-1/2 top-0 w-[1920px]" />
      <div className="absolute h-[311px] left-0 top-[5px] w-[466px]" data-name="download 1">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
      </div>
      <div className="-translate-y-1/2 absolute flex h-[321px] items-center justify-center right-0 top-[calc(50%+0.5px)] w-[482px]">
        <div className="-scale-y-100 flex-none rotate-180">
          <div className="h-[321px] relative w-[482px]" data-name="download 2">
            <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
          </div>
        </div>
      </div>
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Playball:Regular',sans-serif] h-[117px] leading-[normal] left-[914px] not-italic text-[96px] text-black text-center top-[102px] w-[684px]">Sứ mệnh</p>
    </div>
  );
}

function Frame4() {
  return (
    <div className="absolute h-[320px] left-0 top-[3344px] w-[1920px]">
      <div className="-translate-x-1/2 absolute bg-[#e2d9c8] h-[320px] left-1/2 top-0 w-[1920px]" />
      <div className="absolute h-[311px] left-0 top-[5px] w-[466px]" data-name="download 1">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
      </div>
      <div className="-translate-y-1/2 absolute flex h-[321px] items-center justify-center right-0 top-[calc(50%+0.5px)] w-[482px]">
        <div className="-scale-y-100 flex-none rotate-180">
          <div className="h-[321px] relative w-[482px]" data-name="download 2">
            <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
          </div>
        </div>
      </div>
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Playball:Regular',sans-serif] h-[117px] leading-[normal] left-[914px] not-italic text-[96px] text-black text-center top-[102px] w-[684px]">Giá trị cốt lõi</p>
    </div>
  );
}

function Frame3() {
  return (
    <div className="absolute h-[320px] left-0 top-[2185px] w-[1920px]">
      <div className="-translate-x-1/2 absolute bg-[#e2d9c8] h-[320px] left-1/2 top-0 w-[1920px]" />
      <div className="absolute h-[311px] left-0 top-[5px] w-[466px]" data-name="download 1">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
      </div>
      <div className="-translate-y-1/2 absolute flex h-[321px] items-center justify-center right-0 top-[calc(50%+0.5px)] w-[482px]">
        <div className="-scale-y-100 flex-none rotate-180">
          <div className="h-[321px] relative w-[482px]" data-name="download 2">
            <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgDownload1} />
          </div>
        </div>
      </div>
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Playball:Regular',sans-serif] h-[124px] leading-[normal] left-[913px] not-italic text-[96px] text-black text-center top-[98px] w-[634px]">Tầm Nhìn</p>
    </div>
  );
}

function SocialMedia() {
  return (
    <div className="absolute contents left-[1371px] top-[5613px]" data-name="social-media">
      <div className="absolute left-[1507px] rounded-[10px] size-[24px] top-[5613px]" data-name="pinterest">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
          <path d={svgPaths.p17f741f0} fill="var(--fill-0, #E60023)" id="bg" />
        </svg>
        <div className="absolute bottom-[26.25%] left-1/4 right-[25.31%] top-1/4" data-name="pinterest">
          <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 11.9265 11.7">
            <path d={svgPaths.p1d787f00} fill="var(--fill-0, white)" id="pinterest" />
          </svg>
        </div>
      </div>
      <div className="absolute left-[1473px] rounded-[5px] size-[24px] top-[5613px]" data-name="instagram">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
          <path d={svgPaths.p17f741f0} fill="var(--fill-0, #F00073)" id="bg" />
        </svg>
        <div className="absolute inset-[24.06%]" data-name="instagram">
          <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 12.45 12.45">
            <g id="instagram">
              <path d={svgPaths.p3fa1d280} fill="white" />
              <path d={svgPaths.pf647a00} fill="white" />
              <path d={svgPaths.p1d34f200} fill="white" />
            </g>
          </svg>
        </div>
      </div>
      <div className="absolute left-[1371px] rounded-[10px] size-[24px] top-[5613px]" data-name="facebook">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
          <path d={svgPaths.p17f741f0} fill="var(--fill-0, #1877F2)" id="bg" />
        </svg>
        <div className="absolute inset-1/4" data-name="facebook">
          <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 12 12">
            <path d={svgPaths.p3492bff0} fill="var(--fill-0, white)" id="facebook" />
          </svg>
        </div>
      </div>
      <div className="absolute left-[1405px] rounded-[10px] size-[24px] top-[5613px]" data-name="linkedin">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
          <path d={svgPaths.p17f741f0} fill="var(--fill-0, #2867B2)" id="bg" />
        </svg>
        <div className="absolute inset-1/4" data-name="linkedin">
          <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 12 12">
            <path d={svgPaths.p222d5700} fill="var(--fill-0, white)" id="linkedin" />
          </svg>
        </div>
      </div>
      <div className="absolute left-[1439px] rounded-[10px] size-[24px] top-[5613px]" data-name="youtube">
        <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
          <path d={svgPaths.p19d45100} fill="var(--fill-0, #FF0000)" id="bg" />
        </svg>
        <div className="absolute bottom-[32.5%] left-1/4 right-1/4 top-[32.5%]" data-name="youtube">
          <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 12 8.4">
            <path d={svgPaths.p2e73180} fill="var(--fill-0, white)" id="youtube" />
          </svg>
        </div>
      </div>
    </div>
  );
}

function PopularCategories() {
  return (
    <div className="absolute contents left-[1371px] top-[5574px]" data-name="Popular categories">
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[normal] left-[1371px] text-[16px] text-white top-[5574px] whitespace-nowrap">Follow Us</p>
      <SocialMedia />
    </div>
  );
}

function Component3() {
  return (
    <div className="absolute contents left-[1341px] top-[5548px]" data-name="4">
      <div className="absolute bg-[#17100e] h-[116px] left-[1341px] top-[5548px] w-[338px]" data-name="Rectangle" />
      <PopularCategories />
    </div>
  );
}

function VuesaxLinearLocation() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/location">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="location">
          <path d={svgPaths.p159ad400} id="Vector" stroke="var(--stroke-0, #FD84B2)" strokeWidth="2.5" />
          <path d={svgPaths.p54c5b00} id="Vector_2" stroke="var(--stroke-0, #FD84B2)" strokeWidth="2.5" />
          <g id="Vector_3" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Component() {
  return (
    <div className="absolute contents left-[238px] top-[5549px]" data-name="1">
      <div className="absolute bg-[#17100e] h-[116px] left-[238px] top-[5549px] w-[338px]" data-name="Rectangle" />
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[1.7] left-[304px] text-[16px] text-white top-[5581px] w-[242px]">5609 E Sprague Ave, Spokane Valley, WA 99212, USA</p>
      <div className="absolute left-[271px] size-[24px] top-[5579px]" data-name="vuesax/linear/location">
        <VuesaxLinearLocation />
      </div>
    </div>
  );
}

function VuesaxLinearCall() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/call">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="call">
          <g id="call_2">
            <path d={svgPaths.pa7f1800} id="Vector" stroke="var(--stroke-0, #FD84B2)" strokeMiterlimit="10" strokeWidth="2.5" />
          </g>
          <g id="Vector_2" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Component1() {
  return (
    <div className="absolute contents left-[606px] top-[5549px]" data-name="2">
      <div className="absolute bg-[#17100e] h-[116px] left-[606px] top-[5549px] w-[338px]" data-name="Rectangle" />
      <div className="absolute left-[639px] size-[24px] top-[5595px]" data-name="vuesax/linear/call">
        <VuesaxLinearCall />
      </div>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[1.7] left-[673px] text-[16px] text-white top-[5594px] whitespace-nowrap">+ 1834 123 456 789</p>
    </div>
  );
}

function VuesaxLinearSms() {
  return (
    <div className="absolute contents inset-0" data-name="vuesax/linear/sms">
      <svg className="absolute block inset-0 size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 24 24">
        <g id="sms">
          <path d={svgPaths.p1b81e780} id="Vector" stroke="var(--stroke-0, #FD84B2)" strokeLinecap="round" strokeLinejoin="round" strokeMiterlimit="10" strokeWidth="2.5" />
          <path d={svgPaths.p31dc2600} id="Vector_2" stroke="var(--stroke-0, #FD84B2)" strokeLinecap="round" strokeLinejoin="round" strokeMiterlimit="10" strokeWidth="2.5" />
          <g id="Vector_3" opacity="0" />
        </g>
      </svg>
    </div>
  );
}

function Component2() {
  return (
    <div className="absolute contents left-[973px] top-[5549px]" data-name="3">
      <div className="absolute bg-[#17100e] h-[116px] left-[973px] top-[5549px] w-[338px]" data-name="Rectangle" />
      <div className="absolute left-[1003px] size-[24px] top-[5595px]" data-name="vuesax/linear/sms">
        <VuesaxLinearSms />
      </div>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[1.7] left-[1037px] text-[16px] text-white top-[5594px] whitespace-nowrap">support1@example.com</p>
    </div>
  );
}

function MaskGroup1() {
  return (
    <div className="absolute contents left-[241px] top-[5287px]" data-name="Mask group">
      <div className="absolute bg-white left-[227.29px] mask-alpha mask-intersect mask-no-clip mask-no-repeat mask-position-[13.714px_6.857px] mask-size-[40px_40px] size-[68.571px] top-[5280.14px]" style={{ maskImage: `url('${imgRectangle24032}')` }} />
    </div>
  );
}

function Logo1() {
  return (
    <div className="absolute contents left-[241px] top-[5287px]" data-name="logo">
      <div className="-translate-y-1/2 [word-break:break-word] absolute flex flex-col font-['Work_Sans:Regular',sans-serif] font-normal justify-center leading-[0] left-[291px] text-[20px] text-white top-[5320px] whitespace-nowrap">
        <p className="font-['Work_Sans:ExtraBold',sans-serif] font-extrabold leading-none mb-0 text-[#f06b9a] whitespace-pre">{`Sweet `}</p>
        <p className="leading-none mb-0 whitespace-pre">{`Shell Cup `}</p>
        <p className="leading-none whitespace-pre">​</p>
      </div>
      <MaskGroup1 />
    </div>
  );
}

function Footer() {
  return (
    <div className="absolute contents left-0 top-[5137px]" data-name="footer">
      <div className="absolute bg-[#201613] h-[684px] left-0 top-[5137px] w-[1920px]" data-name="Rectangle" />
      <Component3 />
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:Regular',sans-serif] font-normal leading-[0] left-[241px] text-[0px] text-white top-[5769px] whitespace-nowrap">
        <span className="leading-[normal] text-[16px]">© 202</span>
        <span className="leading-[normal] text-[16px]">6</span>
        <span className="leading-[normal] text-[16px]">&nbsp;</span>
        <span className="font-['Work_Sans:Medium',sans-serif] font-medium leading-[normal] text-[#fd84b2] text-[16px]">Sweet Shell Cup</span>
        <span className="leading-[normal] text-[16px]">. All Rights Reserved</span>
      </p>
      <ul className="[word-break:break-word] absolute block capitalize font-['Work_Sans:Regular',sans-serif] font-normal leading-[0] left-[1228px] list-disc text-[14px] text-white top-[5338px] whitespace-nowrap">
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Our story</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Contacts</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Affiliate Program</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Referral Program</span>
        </li>
        <li className="ms-[21px]">
          <span className="leading-[30px]">Careers</span>
        </li>
      </ul>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[normal] left-[1228px] text-[16px] text-white top-[5287px] whitespace-nowrap">About Us</p>
      <ul className="[word-break:break-word] absolute block capitalize font-['Work_Sans:Regular',sans-serif] font-normal leading-[0] left-[1565px] list-disc text-[14px] text-white top-[5338px] whitespace-nowrap">
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Gelato</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Kulfi</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Sherbet</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Sorbet</span>
        </li>
        <li className="ms-[21px]">
          <span className="leading-[30px]">Frozen Yogurt</span>
        </li>
      </ul>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[normal] left-[1565px] text-[16px] text-white top-[5287px] whitespace-nowrap">Categories</p>
      <ul className="[word-break:break-word] absolute block capitalize font-['Work_Sans:Regular',sans-serif] font-normal leading-[0] left-[602px] list-disc text-[14px] text-white top-[5338px] whitespace-nowrap">
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Help Center</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Shipping</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Returns</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Policies</span>
        </li>
        <li className="ms-[21px]">
          <span className="leading-[30px]">Gift Cards</span>
        </li>
      </ul>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[normal] left-[602px] text-[16px] text-white top-[5287px] whitespace-nowrap">Information</p>
      <Component />
      <Component1 />
      <Component2 />
      <ul className="[word-break:break-word] absolute block capitalize font-['Work_Sans:Regular',sans-serif] font-normal leading-[0] left-[906px] list-disc text-[14px] text-white top-[5338px] whitespace-nowrap">
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">My Account</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Order Tracking</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">All Products</span>
        </li>
        <li className="mb-0 ms-[21px]">
          <span className="leading-[30px]">Ingredients</span>
        </li>
        <li className="ms-[21px]">
          <span className="leading-[30px]">Wholesale</span>
        </li>
      </ul>
      <p className="[word-break:break-word] absolute capitalize font-['Work_Sans:SemiBold',sans-serif] font-semibold leading-[normal] left-[906px] text-[16px] text-white top-[5287px] whitespace-nowrap">Useful Links</p>
      <div className="absolute h-0 left-[241px] top-[5735px] w-[1438px]">
        <div className="absolute inset-[-1px_0_0_0]">
          <svg className="block size-full" fill="none" preserveAspectRatio="none" viewBox="0 0 1438 1">
            <line id="Line 192" opacity="0.2" stroke="var(--stroke-0, white)" x2="1438" y1="0.5" y2="0.5" />
          </svg>
        </div>
      </div>
      <div className="absolute h-[26px] left-[1353px] top-[5765px] w-[326px]" data-name="image 377">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgImage377} />
      </div>
      <Logo1 />
      <p className="[word-break:break-word] absolute font-['Work_Sans:Regular',sans-serif] font-normal leading-[24px] left-[241px] text-[14px] text-white top-[5338px] w-[217px]">Sweet Shell là chiếc cốc đồ uống có thể ăn được, kết hợp đồ uống, bao bì và món tráng miệng trong một trải nghiệm duy nhất.</p>
    </div>
  );
}

function Frame5() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#533931] text-[16px] text-center whitespace-nowrap">Home</p>
    </div>
  );
}

function Frame6() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#fd84b2] text-[16px] text-center whitespace-nowrap">Our Story</p>
    </div>
  );
}

function Frame7() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#533931] text-[16px] text-center whitespace-nowrap">Shop</p>
    </div>
  );
}

function Frame8() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#533931] text-[16px] text-center whitespace-nowrap">Cart</p>
    </div>
  );
}

function Frame9() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#533931] text-[16px] text-center whitespace-nowrap">Feedback</p>
    </div>
  );
}

function Frame10() {
  return (
    <div className="content-stretch flex items-center justify-center p-[10px] relative shrink-0">
      <p className="[word-break:break-word] font-['Work_Sans:Medium',sans-serif] font-medium leading-[1.1] relative shrink-0 text-[#533931] text-[16px] text-center whitespace-nowrap">Contact</p>
    </div>
  );
}

function Menu() {
  return (
    <div className="absolute content-stretch flex gap-[59px] items-center justify-center left-[450px] top-[85px]" data-name="Menu">
      <Frame5 />
      <Frame6 />
      <Frame7 />
      <Frame8 />
      <Frame9 />
      <Frame10 />
    </div>
  );
}

export default function OurStory() {
  return (
    <div className="bg-white relative size-full" data-name="Our Story">
      <Header />
      <PastriesInAdditionToIceCream />
      <Frame2 />
      <Frame />
      <Frame4 />
      <Frame3 />
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Playfair:Bold',sans-serif] font-bold h-[218px] leading-[normal] left-[960px] text-[48px] text-black text-center top-[2546px] w-[1920px]" style={{ fontVariationSettings: "'opsz' 12, 'wdth' 100" }}>
        Trở thành thương hiệu tiên phong mang cốc ăn được đến gần hơn với ngành đồ uống, tạo nên trải nghiệm thưởng thức mới mẻ và thân thiện với môi trường tại Việt Nam.
      </p>
      <p className="-translate-x-1/2 [word-break:break-word] absolute font-['Playfair:Bold',sans-serif] font-bold h-[237px] leading-[normal] left-[969px] text-[48px] text-black text-center top-[3107px] w-[1844px]" style={{ fontVariationSettings: "'opsz' 12, 'wdth' 100" }}>
        Sweet Shell Cup được tạo ra nhằm biến một chiếc cốc dùng một lần thành một phần của trải nghiệm thưởng thức, giúp giảm rác thải, mang đến sự khác biệt cho các cửa hàng đồ uống và lan tỏa lối sống xanh đến người tiêu dùng.
      </p>
      <div className="-translate-x-1/2 [word-break:break-word] absolute font-['Playfair:Bold',sans-serif] font-bold h-[411px] leading-[0] left-[953px] text-[48px] text-black text-center top-[3705px] w-[1920px]" style={{ fontVariationSettings: "'opsz' 12, 'wdth' 100" }}>
        <p className="leading-[normal] mb-0">Sáng tạo – Mới lạ và khác biệt</p>
        <p className="leading-[normal] mb-0">Bền vững – Giảm rác thải</p>
        <p className="leading-[normal] mb-0">Chất lượng – An toàn và ngon</p>
        <p className="leading-[normal] mb-0">Khách hàng là trung tâm – Lắng nghe để cải thiện</p>
        <p className="leading-[normal]">Khác biệt – Tạo trải nghiệm đáng nhớ</p>
      </div>
      <div className="absolute h-[991px] left-0 top-[4060px] w-[1920px]">
        <img alt="" className="absolute inset-0 max-w-none object-cover pointer-events-none size-full" src={imgRectangle24040} />
      </div>
      <Footer />
      <Menu />
    </div>
  );
}